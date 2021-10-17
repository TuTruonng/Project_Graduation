import Header  from './Components/Header';
import Navbar from './Components/Navbar';
import './App.css';
import ListLoaiBDS from './Pages/LoaiBatDongSan/ListLoaiBDS.js';
import LoaiBDSForm from './Pages/LoaiBatDongSan/LoaiBDSForm';
import { Router, Route, Switch } from 'react-router';
import  history  from './Helpers/Help';
import ListNhanVien from './Pages/NhanVien/ListNhanVien';
import {LIST_CATEGORY, LIST_USER,CREATE_CATEGORY,UPDATE_CATEGORY, UPDATE_NEWS, CREATE_NEWS,LIST_NEWS, LIST_BDS} from './Helpers/Router';
import ListTinTuc from './Pages/TinTuc/ListTinTuc';
import TinTucForm from './Pages/TinTuc/TinTucForm';
import ListBDS from './Pages/BatDongSan/ListBDS';

function App() {
  return (
    <div className="App">
        <Navbar />
        <Header />
        <Router history = {history}>
        <Switch>

          <Route path = {LIST_CATEGORY} >
            <ListLoaiBDS />
          </Route>
          
          <Route path = {CREATE_CATEGORY}>
           <LoaiBDSForm />
          </Route>

          <Route path = {UPDATE_CATEGORY}>
           <LoaiBDSForm />
          </Route>

          <Route path = {LIST_USER}>
           <ListNhanVien />
          </Route>

          <Route path = {LIST_NEWS}>
           <ListTinTuc />
          </Route>

          <Route path = {CREATE_NEWS}>
           <TinTucForm />
          </Route>

          <Route path = {UPDATE_NEWS}>
           <TinTucForm />
          </Route>

          <Route path = {LIST_BDS}>
           <ListBDS />
          </Route>
          
        </Switch>
        </Router>
    </div>
  );
}


export default App;
