import React from "react";
import { Link } from "react-router-dom"

export default function Book() {
    return (
        <div className="BookContainer">
            <header>
                <img/>
                <span>Bem vindo, <strong>usuario</strong></span>
                <Link className="button" to="book/new">Adicionar novo livro</Link>
                <button type="button" />
            </header>
        </div>
    );
}