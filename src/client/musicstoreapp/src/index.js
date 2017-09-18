import React from 'react';
import ReactDOM from 'react-dom';
import '../styles/index.css';
// import RootContainer from './containers/RootContainer/Root.Container';
import Root from './components/rootComponent/Root.Component';
import App from './components/App';
import registerServiceWorker from './registerServiceWorker';

// ReactDOM.render(<RootContainer />, document.getElementById('root'));
// ReactDOM.render(<Root />, document.getElementById('root'));
ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();
