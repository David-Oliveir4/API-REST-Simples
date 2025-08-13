import { useEffect, useState } from 'react'
import axios from 'axios'

const API = 'http://localhost:5000'

export default function App() {
  const [items, setItems] = useState([])
  const [form, setForm] = useState({ name: '', price: '', category: '' })
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState('')

  const load = async () => {
    const { data } = await axios.get(`${API}/produto`)
    setItems(data)
  }

  useEffect(() => { load() }, [])

  const onChange = (e) => {
    const { name, value } = e.target
    setForm((f) => ({ ...f, [name]: value }))
  }

  const onSubmit = async (e) => {
    e.preventDefault()
    setLoading(true); setError('')
    try {
      const payload = {
        name: form.name,
        price: parseFloat(form.price || '0'),
        category: form.category
      }
      await axios.post(`${API}/produto`, payload)
      setForm({ name: '', price: '', category: '' })
      await load()
    } catch (err) {
      setError(err?.response?.data?.error || 'Erro ao salvar')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div style={{ maxWidth: 720, margin: '40px auto', fontFamily: 'Inter, system-ui, Arial' }}>
      <h1>Cadastro de Produtos</h1>

      <form onSubmit={onSubmit} style={{ display: 'grid', gap: 8, marginBottom: 24 }}>
        <input name="name" placeholder="Nome" value={form.name} onChange={onChange} required />
        <input name="price" placeholder="Preço" type="number" step="0.01" value={form.price} onChange={onChange} required />
        <input name="category" placeholder="Categoria" value={form.category} onChange={onChange} required />
        <button disabled={loading}>{loading ? 'Salvando...' : 'Salvar'}</button>
        {error && <div style={{ color: 'crimson' }}>{error}</div>}
      </form>

      <h2>Lista</h2>
      <ul>
        {items.map(p => (
          <li key={p.id}>{p.id} — {p.name} — R$ {p.price} — {p.category}</li>
        ))}
      </ul>
    </div>
  )
}
