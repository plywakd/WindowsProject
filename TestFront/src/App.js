import React, {Component} from 'react';
import {UserMenu} from './components/UserMenu/UserMenu';
import {Content} from './components/Content/Content';
import {Toolbar} from './components/Toolbar/Toolbar';
import './app.css';

class App extends Component{

	constructor(props) {
		super(props);
		this.state = {
            username : "",
            password : "",
            isLogged : false,
		}
	}
	
	componentDidMount() {
	    console.log("Loaded App js");
	}
	
	render() {
		return (
			<React.Fragment>
				<div className="main-container">
					<div className="row-container">
						<Toolbar></Toolbar>
					</div>
					<div className="row-container">
						<UserMenu></UserMenu>
						<Content></Content>
					</div>
				</div>
			</React.Fragment>
		);
	}
}

export default App;