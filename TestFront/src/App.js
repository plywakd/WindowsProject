import React, {Component} from 'react';

import {Content} from './components/Content/Content';
import {Toolbar} from './components/Toolbar/Toolbar';
import './app.css';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.min.css';

class App extends Component{

	constructor(props) {
		super(props);
		this.state = {
            username : "",
            password : "",
            isLogged : false,
			launchGame : false,
			showRanking : false,
			tmp : null,
			content : null
		}
		this.handleLogin = this.handleLogin.bind(this);
		this.handleLaunchGame = this.handleLaunchGame.bind(this);
		this.handleRanking = this.handleRanking.bind(this);
	}
	
	componentDidMount() {
	    console.log("Loaded App js");
	}
	
	handleLogin() {
		console.log("Login");
		this.setState({content : <Content login={this.state.isLogged}></Content>});
		this.setState({isLogged: true});
	}
	
	handleLaunchGame() {
		console.log("Game start");
		this.setState({launchGame : true}, () => this.setState({content : <Content launchGame={this.state.launchGame}></Content>}));
	}
	
	handleRanking() {
		console.log("Ranking start");
		this.setState({showRanking : true},() => this.setState({content : <Content showRanking={this.state.showRanking}></Content>}));
	}
	
	render() {
		return (
			<React.Fragment>
				<div className="main-container">
					<div className="row-container">
						<Toolbar></Toolbar>
					</div>
					<div className="row-container">
						<div className="user-menu-container">
							<h4>Hello from userMenu</h4>
							<div className="btn-container">
								<Button variant="dark" onClick={this.handleLogin}>Login</Button>
								<Button variant="dark" disabled = {!this.state.isLogged} onClick={this.handleLaunchGame}>Train Game!</Button>
								<Button variant="dark" disabled = {!this.state.isLogged} onClick={this.handleRanking}>Ranking</Button>
							</div>
						</div>
						{this.state.content}
					</div>
				</div>
			</React.Fragment>
		);
	}
}

export default App;