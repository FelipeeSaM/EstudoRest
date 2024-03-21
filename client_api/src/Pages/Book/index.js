import React, {useEffect, useState} from "react";
import { Link, useNavigate } from "react-router-dom"
import api from '../../Services/api'

export default function Book() {

    const [books, setBooks] = useState([]);
    const userName = localStorage.getItem('userName');
    const tokenAcesso = localStorage.getItem("tokenAcesso");
    const navigate = useNavigate();

    useEffect(() => {
        api.get('/api/v1/livro', {
            headers: {
                tokenAcesso: `Bearer ${tokenAcesso}`
            }
        }).then(response => {
            console.table(response.data)
            setBooks(response.data)
        })
    }, [tokenAcesso])

    async function UpdateBook(id) {
        try {
            navigate(`/books/new/${id}`)
        } catch(err) {
            alert("Nao redirecionou")
        }
    }

    async function DeleteBook(id) {
        try {
            await api.delete(`/api/v1/livro/${id}`, {
                headers: {
                    tokenAcesso: `Bearer ${tokenAcesso}`
                }
            });
    
            setBooks(books.filter(book => book.id !== id))
        } catch(err) {
            alert("deletou n")
        }
    }

    async function Logout() {
        try {
            await api.get(`/api/v1/auth/revoke`, {
                headers: {
                    tokenAcesso: `Bearer ${tokenAcesso}`
                }
            });
    
            localStorage.clear();
            navigate("/");
        } catch(err) {
            alert("deslogou n");
        }
    }

    return (
        <div className="BookContainer">
            <header>
                <span>Bem vindo, <strong>{userName}</strong></span>
                <Link className="button" to="/books/new/0">Adicionar novo livro</Link>
                <button type="button">clique aqui</button>
                <button onClick={Logout}>deslogar</button>
            </header>

            <ul>
                {books.map(book => (
                     <li key={book.id}>
                     <strong>Titulo:</strong> 
                     <p>{book.nome}</p>
                     <strong>Autor:</strong> 
                     <p>{book.autor}</p>
                     <strong>Preço:</strong> 
                     <p>{Intl.NumberFormat('pt-BR', {style: 'currency', currency: 'BRL'}).format(book.preco)}</p>
                     <strong>Disponivel:</strong> 
                     <p><input type="checkbox"></input> {book.estoque}</p>
                     <button onClick={() => UpdateBook(book.id)} >Atualizar</button>
                     <button onClick={() => DeleteBook(book.id)} >deletar</button>
                 </li>               
                ))}
            </ul>
        </div>
    );
}