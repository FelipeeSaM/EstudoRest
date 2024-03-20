import React, {useState}  from "react";
import { useNavigate  } from 'react-router-dom';
import api from '../../Services/api'

export default function Login(props) {

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    async function login(e) {
        e.preventDefault();

        const data = {
            userName, password
        };

        try {
            const response = await api.post('/api/v1/auth/signin', data);
            localStorage.setItem('userName', userName);
            localStorage.setItem('tokenAcesso', response.data.tokenAcesso);
            localStorage.setItem('refreshToken', response.data.refreshToken);

            navigate("/books");
        } catch(error) {
            alert("n deu")
        }
    }

    return (
        <div className="login-container">
            <form onSubmit={login}>
                <h1>Tela de login</h1>
                <input placeholder="username" value={userName} onChange={e => setUserName(e.target.value)} />
                <input type="password" placeholder="Password" value={password} onChange={e => setPassword(e.target.value)} />
                <button type="submit">Login </button>
            </form>
        </div>
    );
}