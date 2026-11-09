// frontend/src/features/Carros/components/CatalogoCarrosView.tsx
// frontend/src/features/Carros/components/CatalogoCarrosView.tsx
import { useState, useEffect } from 'react'
import type { CarroGlobal } from '../types/carro.types'
import { obtenerCarrosGlobalesAsync, extraerMensajeErrorBackend } from '../api/carrosApi'
import { CarroGlobalCard } from './CarroGlobalCard'
import { CrearCarroForm } from './CrearCarroForm'

export function CatalogoCarrosView() {
  const [Carros, setCarros] = useState<CarroGlobal[]>([])
  const [cargando, setCargando] = useState<boolean>(true)
  const [errorRed, setErrorRed] = useState<string | null>(null)
  const [busqueda, setBusqueda] = useState<string>('')
  const [mostrarFormulario, setMostrarFormulario] = useState<boolean>(false)

  useEffect(() => {
    obtenerCarrosGlobalesAsync()
      .then((datosDesdePostgres) => {
        setCarros(datosDesdePostgres)
        setErrorRed(null)
      })
      .catch((error) => {
        console.error('Auditoría de Error en la Petición HTTP:', error)
        setErrorRed(extraerMensajeErrorBackend(error))
      })
      .finally(() => {
        setCargando(false)
      })
  }, [])

  // Actualización Inmutable en el Heap usando Spread Operator [...]
  const manejarCarroCreado = (nuevoCarroDesdeBD: CarroGlobal) => {
    setCarros((CarrosActuales) => [...CarrosActuales, nuevoCarroDesdeBD])
    setMostrarFormulario(false)
  }

  const CarrosFiltrados = Carros.filter((Carro) =>
    Carro.nombre.toLowerCase().includes(busqueda.toLowerCase())
  )

  return (
    <div>
      <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 pb-6 mb-6 border-b border-slate-800">
        <div>
          <h1 className="text-2xl md:text-3xl font-bold text-white">Catálogo Global de Hábitos</h1>
          <p className="text-slate-400 text-sm mt-1">
            Conectado en tiempo real vía HTTP/CORS con <code className="text-indigo-400 font-mono">PostgreSQL</code>.
          </p>
        </div>

        {!mostrarFormulario && (
          <button 
            onClick={() => setMostrarFormulario(true)}
            className="bg-indigo-600 hover:bg-indigo-500 text-white font-medium text-sm px-4 py-2.5 rounded-lg transition-colors shadow-sm self-start sm:self-auto cursor-pointer"
          >
            + Nuevo Hábito Global
          </button>
        )}
      </div>

      {/* Renderizado condicional del Formulario POST */}
      {mostrarFormulario && (
        <CrearCarroForm 
          onCarroCreado={manejarCarroCreado}
          onCancelar={() => setMostrarFormulario(false)}
        />
      )}

      <div className="mb-6 flex flex-col sm:flex-row sm:items-center justify-between gap-4">
        <input
          type="text"
          placeholder="🔍 Filtrar hábitos provenientes de PostgreSQL..."
          value={busqueda}
          onChange={(e) => setBusqueda(e.target.value)}
          className="w-full sm:max-w-md bg-slate-950 border border-slate-800 rounded-lg px-4 py-2.5 text-sm text-white placeholder-slate-500 focus:outline-none focus:border-indigo-500 transition-colors"
        />
        <span className="text-xs text-slate-400">
          Mostrando <strong className="text-white">{CarrosFiltrados.length}</strong> de {Carros.length} registros en BD
        </span>
      </div>

      {cargando && (
        <div className="bg-slate-800/50 border border-slate-800 rounded-xl p-12 text-center">
          <p className="text-indigo-400 font-semibold animate-pulse text-lg">
            ⏳ Consultando endpoint GET /api/Carros en .NET...
          </p>
        </div>
      )}

      {!cargando && errorRed && (
        <div className="bg-red-950/40 border border-red-500/40 rounded-xl p-6 text-center">
          <p className="text-red-400 font-bold text-base mb-1">🚨 Error de Comunicación Full-Stack</p>
          <p className="text-slate-300 text-sm">{errorRed}</p>
        </div>
      )}

      {!cargando && !errorRed && (
        <section className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
          {CarrosFiltrados.map((Carro) => (
            <CarroGlobalCard 
              key={Carro.id} 
              id={Carro.id} 
              nombre={Carro.nombre} 
            />
          ))}
        </section>
      )}
    </div>
  )
}
