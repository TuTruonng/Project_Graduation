import Header  from './Components/Header';
import Navbar from './Components/Navbar';
import './App.css';
import ListCategory from './Pages/LoaiBatDongSan/ListLoaiBDS.js';
import { Router, Route, Switch } from 'react-router';
import  history  from './Helpers/Help';
import ListNhanVien from './Pages/NhanVien/ListNhanVien';
import {LIST_CATEGORY, LIST_USER} from './Helpers/Router';

function App() {
  return (
    <div className="App">
        <Navbar />
        <Header />
        <Router history = {history}>
        <Switch>
          <Route path = {LIST_CATEGORY} >
            <ListCategory />
          </Route>
          <Route path = {LIST_USER}>
           <ListNhanVien />
          </Route>
        </Switch>
        </Router>
    </div>
  );
}


export default App;
