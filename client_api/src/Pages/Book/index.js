import React from "react";
import { Link } from "react-router-dom"

export default function Book() {
    return (
        <div className="BookContainer">
            <header>
                <img/>
                <span>Bem vindo, <strong>usuario</strong></span>
                <Link className="button" to="book/new">Adicionar novo livro</Link>
                <button type="button">clique aqui</button>
            </header>

            <ul>
                <li>
                    <strong>Titulo:</strong> 
                    <p>livro1</p>
                    <strong>Autor:</strong> 
                    <p>Autor1</p>
                    <strong>Preço:</strong> 
                    <p>R$ 29,99</p>
                    <strong>Lançamento:</strong> 
                    <p>20/01/2020</p>
                </li>
            </ul>
        </div>
    );
}