import React from 'react';
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import './App.css';
import { Register } from './components/Register';
import { Login } from './components/Login';
import { Home } from './components/Home';

const App: React.FC = () => {
    return (
        <div>
            <nav className="navbar navbar-expand navbar-dark bg-dark">
                <a href="/tutorials" className="navbar-brand">
                    bezKoder
                </a>
                <div className="navbar-nav mr-auto">
                    <li className="nav-item">
                        <Link to={"/login"} className="nav-link">
                            Ê—Êœ
                        </Link>
                    </li>
                    <li className="nav-item">
                        <Link to={"/register"} className="nav-link">
                            À»  ‰«„
                        </Link>
                    </li>
                </div>
            </nav>
            <div className="container mt-3">
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                   {/* <Route path="/tutorials/:id" element={<Tutorial />} />*/}
                </Routes>
            </div>
        </div>
    );
}
export default App;
{/*//function App() {*/}
{/*//    return (*/}
{/*//        <Register />*/}
{/*//    );*/}
{/*//}*/}
{/*//export default App;*/}