import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Login from './Pages/Login';
import Books from './Pages/Book'


export default function Routers() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/' element={ <Login/> } />
                <Route path='/login' element={ <Login/> } />
                <Route path='/books' element={ <Books/> } />
            </Routes>
        </BrowserRouter>
    );
}
