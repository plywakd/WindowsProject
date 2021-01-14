import React, {Component} from 'react';
import { SubMenu } from '../SubMenu/SubMenu';
import { UserMenu } from '../UserMenu/UserMenu';
import 'bootstrap/dist/css/bootstrap.min.css';
import './content.css';
import axios from 'axios';

class Content extends React.Component{

	constructor(props) {
		super(props);
		this.state = {
			isLogged: false,
			username : '',
			password : '',
			gameList : [],
			gameMenu: false,
			results : [],
		}
		this.handleChange = this.handleChange.bind(this);
		this.handleRegister = this.handleRegister.bind(this);
		this.handleLogin = this.handleLogin.bind(this);
		this.handleFetchGames = this.handleFetchGames.bind(this);
		this.handleRanking = this.handleRanking.bind(this);
		this.handleLaunch = this.handleLaunch.bind(this);
		this.loadGame = this.loadGame.bind(this);
	}

	componentDidMount() {
	    console.log("Content component");
	}
	
	handleChange(event) {
		const target = event.target;
		const value = target.value;
		const name = target.name;
		this.setState({
		  [name]: value    
		});
	}
	
	handleLogin(event){
		event.preventDefault();
		const backend_url = 'https://localhost:44306/Accounts/login'
		axios.get(backend_url, {
			params: {
				username: this.state.username,
			}
		}).
			then(response => {
				console.log(response.status)
				this.setState({
					isLogged: response.status
				})
			})

	}


	handleRegister(event) {
		event.preventDefault();
		const backend_url = 'https://localhost:44306/Accounts/add'
		axios.post(backend_url, {
			params: {
				username: this.state.username,
				password: this.state.password,
			}
		})
			.then(function (response) {
			console.log(response);
			})
	}

	handleFetchGames(event) {
		event.preventDefault();
		this.setState({ gameMenu: true });
		const backend_url = 'https://localhost:44306/Games'
		axios.get(backend_url).
			then(response => {
				console.log(response + ", " + this.state.gameMenu);
				this.setState({
					gameList: response.data
				})
			})
    }

	handleRanking(event) {
		event.preventDefault();
		console.log("ranking handler");
	}

	handleLaunch(event) {
		event.preventDefault();
		console.log("launcher");
    }
	
	loadGame() {
		console.log("Game!");
		this.setState({game_tmp : true});
	}


	render() {
		return (
			<div className = "container" >
				<UserMenu isLogged={this.state.isLogged} handleFetchGames={this.handleFetchGames} handleRanking={this.handleRanking} />
				<SubMenu isLogged={this.state.isLogged} username={this.state.username} gameList={this.state.gameList} gameMenu={this.state.gameMenu} handleLogin={this.handleLogin} handleRegister={this.handleRegister} handleChange = { this.handleChange } />
			</div>			
		);
	}
}

export {Content};