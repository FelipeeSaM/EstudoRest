import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import api from '../../Services/api'

export default function NewBook() {

    const[nome, setNome] = useState('');
    const[autor, setAutor] = useState('');
    const[preco, setPreco] = useState('');
    const[estoque, setEstoque] = useState(false);

    const navigate = useNavigate();

    const handleEstoqueChange = (e) => {
        const valorEstoque = e.target.value === 'true'; // Converte a string para um booleano
        setEstoque(valorEstoque); // Define o estado estoque com o valor booleano
    };
    
    async function CriarNovoLivro(e) {
        e.preventDefault();

        const data = {
            nome, autor, preco, estoque
        }

        const tokenAcesso = localStorage.getItem("tokenAcesso");

        try{
            await api.post('/api/v1/livro', data, {
                headers: {
                    tokenAcesso: `Bearer ${tokenAcesso}`
                }
            })
        }catch(err){
            console.log(err)
        }
        navigate('/books')
    }

    return(
        <div class="book-container">
            <section className="form">
                <h1>Adicionar novo livro</h1>
                <p>Informações do livro:</p>
                <Link to="/books">Voltar</Link>
            </section>

            <form onSubmit={CriarNovoLivro}>
                <input placeholder="Titulo" value={nome} onChange={e => setNome(e.target.value)} />
                <input placeholder="Autor" value={autor} onChange={e => setAutor(e.target.value)}/>
                {/* <input placeholder="Estoque" value={estoque} onChange={e => setEstoque(e.target.value)}/> */}
                <label>Estoque</label><input type="checkbox" onChange={handleEstoqueChange}/>
                <input placeholder="Preco" value={preco} onChange={e => setPreco(e.target.value)}/>
                <button type="submit">Adicionar</button>
            </form>
        </div>
    );
}