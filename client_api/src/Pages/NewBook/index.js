import React from "react";
import { Link } from "react-router-dom";

export default function NewBook() {
    return(
        <div class="book-container">
            <section className="form">
                <h1>Adicionar novo livro</h1>
                <p>Informações do livro:</p>
                <Link to="/books">Voltar</Link>
            </section>
            <form>
                <input placeholder="Titulo" />
                <input placeholder="Autor" />
                <input type="date" />
                <input placeholder="Preco" />
                <button type="submit">Adicionar</button>
            </form>
        </div>
    );
}