import React, { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import api from '../../Services/api'

export default function NewBook() {

    const[id, setId] = useState(null);
    const[nome, setNome] = useState('');
    const[autor, setAutor] = useState('');
    const[preco, setPreco] = useState('');
    const[estoque, setEstoque] = useState(false);
    const { bookId } = useParams();

    const navigate = useNavigate();

    useEffect(() => {
        if(bookId !== '0') {LoadBook()};
    }, [bookId])

    const tokenAcesso = localStorage.getItem("tokenAcesso");

    async function LoadBook() {
        try {
            const response = await api.get(`/api/v1/livro/${bookId}`, {
                headers: {
                    tokenAcesso: `Bearer ${tokenAcesso}`
                }
            })
            const { id, nome, autor, preco, estoque } = response.data;
            setId(id);
            setNome(nome);
            setAutor(autor);
            setPreco(preco);
            setEstoque(estoque);
        } catch (error) {
            alert('nao carregou')
            navigate('/books')
        }
    }

    const handleEstoqueChange = (e) => {
        const valorEstoque = e.target.value === 'true';
        setEstoque(valorEstoque);
    };

    async function CriarOuSalvar(e) {
        e.preventDefault();

        const data = {
            nome, autor, preco, estoque
        }

        try{
            if(bookId === '0') {
                await api.post('/api/v1/livro', data, {
                    headers: {
                        tokenAcesso: `Bearer ${tokenAcesso}`
                    }
                })
            } else {
                data.id = id;
                await api.put('/api/v1/livro', data, {
                    headers: {
                        tokenAcesso: `Bearer ${tokenAcesso}`
                    }
                })
            }
        }catch(err){
            console.log(err)
        }
        navigate('/books')
    }

    return(
        <div class="book-container">
            <section className="form">
                <h1>{bookId === '0' ? 'Adicionar novo' : 'Atualizar'} livro</h1>
                <p>Informações do livro:</p>
                <Link to="/books">Voltar</Link>
            </section>

            <form onSubmit={CriarOuSalvar}>
                <input placeholder="Titulo" value={nome} onChange={e => setNome(e.target.value)} />
                <input placeholder="Autor" value={autor} onChange={e => setAutor(e.target.value)}/>
                <label>Estoque</label><input type="checkbox" onChange={handleEstoqueChange}/>
                <input placeholder="Preco" value={preco} onChange={e => setPreco(e.target.value)}/>
                <button type="submit">{bookId === '0' ? 'Adicionar' : 'Atualizar'}</button>
            </form>
        </div>
    );
}