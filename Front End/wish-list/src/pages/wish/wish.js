import { Component } from 'react';

import Genio from "./Images/image 4.png";
import Divisor from "./Images/image 5.png";
import Lampada from "./Images/Lampada.png";

import './style.css';

class Wish extends Component{
    constructor(props){
        super(props);
        this.state = {
            desejos : [],
            usuario : {},
            email : '',
            senha : '',
            idDesejo : '',            
            descricao : '',
            dataCriacao : ''
        }
    }    

    // métodos para setar os valores passados nos inputs
    email = async (log) =>{
        await this.setState({email : log.target.value})
        console.log('email: ' + this.state.email)
    }
    
    senha = async (log) =>{
        await this.setState({senha : log.target.value})
        console.log('senha: ' + this.state.senha)
    }    

    descricao = async (log) =>{
        await this.setState({descricao : log.target.value})
        console.log('descricao: ' + this.state.descricao)
    }

    dataCriacao = async (log) =>{
        await this.setState({dataCriacao : log.target.value})
        console.log('data de criação ' + this.state.dataCriacao)
    }

    
    // método para listar os desejos quando for feito o login , quando cadastrado e quando excluido
    listar = () =>{

        fetch('http://localhost:5000/api/Desejos/' + this.state.usuario.idUsuario,{

            method : "GET",
        })

        .then(resposta => resposta.json())

        .then(data => this.setState({ desejos : data }))

        .catch( (erro) => console.log(erro) )
    }
    
    // método para logar um usuario ao inserir email e senha
    login = async (event) =>{

        event.preventDefault();

        fetch('http://localhost:5000/api/Usuarios', {

            method : 'POST',

            body : JSON.stringify({
                Email : this.state.email,
                Senha : this.state.senha
            }),

            headers : {
                "Content-Type" : "application/json"
            },
        })

        .then(resposta => resposta.json())

        .then(data => this.setState({usuario : data}))

        .catch((erro) => console.log(erro))

        .then(this.listar)
    }

    // método para cadastrar um novo desejo quando for solicitado
    cadastrar = async (event) => {
        event.preventDefault();
            fetch('http://localhost:5000/api/Desejos', {

                method : 'POST',

                body : JSON.stringify({
                    idUsuario : this.state.usuario.idUsuario,                    
                    descricao : this.state.descricao,
                    dataCriacao : this.state.dataCriacao
                }),

                headers : {
                    "Content-Type" : "application/json"
                },
            })

            .then(console.log("Desejo cadastrado!"))

            .catch(erro => console.log(erro))

            .then(this.listar)        
    }

    // método para excluir um desejo quando for solicitado
    excluir = (wishList) => {
        
        fetch('http://localhost:5000/api/Desejos/' + wishList.idDesejo, {

            method : 'DELETE'
        })

        .then(console.log('excluindo'))

        .catch(erro => console.log(erro))

        .then(this.listar)
    }

    

    // renderização da página
    render(){
        return( 
            
            <div>                
                <header>
                <img id="genio" src={Genio} alt="Genio"/>
                <img id="lampada" src={Lampada} alt="Lampada"/>
                </header>

                <section className="input">                    
                    <h2>Login</h2>
                    <form onSubmit={this.login}>
                        <input
                            type='text'
                            value={this.state.email}
                            onChange={this.email}
                            placeholder='Email'
                        />
                        <input
                            type='password'
                            value={this.state.senha}
                            onChange={this.senha}
                            placeholder='Senha'
                        />
                        <button type='submit'>Logar</button>
                    </form>
                                        
                </section>

                

                <section className="input">
                    <h2 className="h2">Enviar desejo</h2>                    
                    <form onSubmit={this.cadastrar}>                        
                        <input
                            type='text'
                            value={this.state.descricao}
                            onChange={this.descricao}
                            placeholder='Escreva o desejo'
                        />
                        <button type='submit'>Enviar</button>
                    </form>                  

                </section>
                
                <img id="divisor" src={Divisor} alt="Divisor"/>
                    
                <section id="secao-tabela">
                    <h2>Lista dos Desejos</h2>
                    <div id="tabela">
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>                                        
                                    <th>Descrição</th>
                                    <th>Data Criação</th>                                        
                                </tr>
                            </thead>

                            <tbody>
                                {                                    
                                    this.state.desejos.map( (w) => {
                                        return(
                                            <tr key={w.idDesejo}>
                                                <td>{w.idDesejo}</td>
                                                <td>{w.descricao}</td>
                                                <td>{new Date(w.dataCriacao).toLocaleDateString()}</td>
                                                <td><button id="excluir" onClick={() => this.excluir(w)}>Excluir</button></td>
                                            </tr>
                                        )  
                                    } )
                                }
                            </tbody>
                        </table>
                    </div>
                </section> 

            </div>

        )
    }
}

export default Wish