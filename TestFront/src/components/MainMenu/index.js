import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

class Main extends React.Component {
    constructor(props) {
        super(props);
        this.wpmString = " words/min";
        this.state = {
            whiteText: "Tylko jedno w glowie mam, koksu 5 gram...",
            greenText: "",
            wpm: "0" + this.wpmString,
            spaceCounter: 0,
            time: window.performance && window.performance.now && window.performance.timing && window.performance.timing.navigationStart ? window.performance.now() + window.performance.timing.navigationStart : Date.now(),
            ms: 0
        };
        this.keyAction = this.keyAction.bind(this);
        document.addEventListener('keydown', this.keyAction, false);
    }

    keyAction(e) {
        var input = e.key;
        if (input == this.state.whiteText.charAt(0)) {
            this.setState(state => ({
                greenText: this.state.greenText + this.state.whiteText.charAt(0),
                whiteText: this.state.whiteText.substring(1)}))
            console.log("GreenText: " + this.state.greenText);
            console.log("WhiteText: " + this.state.whiteText);
            if (input == ' ') {
                console.log("Word typed in: " + ((window.performance && window.performance.now && window.performance.timing && window.performance.timing.navigationStart ? window.performance.now() + window.performance.timing.navigationStart : Date.now()) - this.state.time) + " Mseconds");
                /*
                this.setState(state => ({
                    seconds: this.state.ms + ((window.performance && window.performance.now && window.performance.timing && window.performance.timing.navigationStart ? window.performance.now() + window.performance.timing.navigationStart : Date.now()) - this.state.time),
                    time: window.performance && window.performance.now && window.performance.timing && window.performance.timing.navigationStart ? window.performance.now() + window.performance.timing.navigationStart : Date.now()
                }));*/

                this.setState(state => ({
                    ms: this.state.ms + ((window.performance && window.performance.now && window.performance.timing && window.performance.timing.navigationStart ? window.performance.now() + window.performance.timing.navigationStart : Date.now()) - this.state.time),
                    time: window.performance && window.performance.now && window.performance.timing && window.performance.timing.navigationStart ? window.performance.now() + window.performance.timing.navigationStart : Date.now(),
                    spaceCounter: this.state.spaceCounter + 1
                }));

                this.setState(state => ({
                    wpm: ((this.state.spaceCounter / this.state.ms) * 60000).toFixed(2) + this.wpmString
                }));
            }
            if (this.state.whiteText.length == 0) {
                this.setState(state => ({
                    ms: this.state.ms + ((window.performance && window.performance.now && window.performance.timing && window.performance.timing.navigationStart ? window.performance.now() + window.performance.timing.navigationStart : Date.now()) - this.state.time),
                    time: window.performance && window.performance.now && window.performance.timing && window.performance.timing.navigationStart ? window.performance.now() + window.performance.timing.navigationStart : Date.now(),
                    spaceCounter: this.state.spaceCounter + 1
                }));

                var endWpmString = ", Text typed in: " + (this.state.ms/1000).toFixed(2) + "sec.";

                this.setState(state => ({
                    wpm: ((this.state.spaceCounter / this.state.ms) * 60000).toFixed(2) + this.wpmString + endWpmString
                }));

                var count = (this.state.greenText.match(/ /g) || []).length + 1;
                var wordsPerMin = (count / this.state.ms) * 60000;
                console.log("Words per minute: " + wordsPerMin);
            }
        }
        
    }

    render() {
        return (
            <div>
                <h1><span><font color='green'>{this.state.greenText}</font>{this.state.whiteText}</span></h1>
                <h3>{this.state.wpm}</h3>
            </div>
        );
    }
}

// ========================================

ReactDOM.render(
    <Main />,
    document.getElementById('root')
);