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
			gameLauch: false,
			showRanking: false,
			results : [],
		}
		this.handleChange = this.handleChange.bind(this);
		this.handleRegister = this.handleRegister.bind(this);
		this.handleLogin = this.handleLogin.bind(this);
		this.handleFetchGames = this.handleFetchGames.bind(this);
		this.handleRanking = this.handleRanking.bind(this);
		this.handleLaunch = this.handleLaunch.bind(this);
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
		axios.post(backend_url, {
			username: this.state.username,
			password: this.state.password,
		}).
			then(response => {
				(response.status == 200) ? this.setState({ isLogged: true }) : this.setState({ isLogged: false})
			})
	}


	handleRegister(event) {
		event.preventDefault();
		const backend_url = 'https://localhost:44306/Accounts/add'
		axios.post(backend_url, {
			username: this.state.username,
			password: this.state.password,
		})
			.then(function (response) {
			console.log(response);
			})
	}

	handleFetchGames(event) {
		event.preventDefault();
		this.setState({ gameMenu: true }, () => { console.log(this.state.gameMenu) });
		const backend_url = 'https://localhost:44306/Games'
		axios.get(backend_url).
			then(response => {
				console.log(response.data);
				this.setState({
					gameList: response.data
				}, () => {
						console.log("Data is ready");
				})
			});
    }

	handleRanking(event) {
		event.preventDefault();
		this.setState({ showRanking: true }, () => { console.log(this.state.showRanking) });
		const backend_url = 'https://localhost:44306/Results';
		axios.get(backend_url).
			then(response => {
				console.log(response.data);
				this.setState({ results: response.data }, () => { console.log(this.state.results) });
			});
	}

	handleLaunch(event) {
		event.preventDefault();
    }
	

	render() {
		return (
			<div className="row-container">
				<UserMenu isLogged={this.state.isLogged} handleFetchGames={this.handleFetchGames} handleRanking={this.handleRanking} />
				<SubMenu isLogged={this.state.isLogged} username={this.state.username} gameList={this.state.gameList} gameMenu={this.state.gameMenu} gameLauch={this.state.gameLauch} showRanking={this.state.showRanking} results={this.state.results} handleLogin={this.handleLogin} handleRegister={this.handleRegister} handleChange={this.handleChange} handleGame={this.handleGame} />
			</div>			
		);
	}
}

export {Content};