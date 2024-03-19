import React  from "react";

export default function Login(props) {
    return (
        <div className="login-container">
            <form>
                <h1>Tela de login</h1>
                <input placeholder="username" />
                <input type="password" placeholder="Password" />
                <button type="submit">Login </button>
            </form>
        </div>
    );
}