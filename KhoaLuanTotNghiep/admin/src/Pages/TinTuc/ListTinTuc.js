import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import TinTucService from "../../Services/TinTucService";
import "./TinTuc.css"

const ListTinTuc = () => {
  const [news, setnews] = useState([]);
  const [itemSelected, setSelected] = React.useState(null);
  let params = {};
  useEffect(() => {
    params = {     
      query: "",
    };
    _fetchNews();
  }, []);


  const _fetchNews = () => {
    TinTucService.getList().then(({ data }) => setnews(data));
  };
  console.log("leduyen");
  const handleCreate = () => setSelected({ Name: "", TypeProductId: 0 });

  const handleDelete = (itemId) => {
    let result = window.confirm("Delete this item?");
    if (result) {
        TinTucService.delete(itemId).then((resp) => {
        setnews(_removeViewItem(news, itemId));
      });
    }
  };

  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.newsID !== itemDel);

    const handleSearch = (query) => {
      params.query = query;
      _fetchNews();
    };
  
    const handleSearchKey = () => {
      params.query = "";
      _fetchNews();
    };
  

  return (
    <div class="content-wrapper">
      <br />
      <h3  style={{color:"#58257b", fontSize:"36px"}}>Tin Tức</h3>
      <br />
      <div className="text-right">
        <div className="row" style={{ marginLeft: "500px" }}>
          <div class="col-sm-6"  >
            <div className="input-group" data-widget="sidebar-search"  >
              <input       
                className="form-control form-control-sidebar"
                type="search"
                placeholder="Search"
                aria-label="Search"
              />
              <div className="input-group-append" style={{border: "1px dotted #e0dcdc"}}>
                <button className="btn btn-sidebar">
                  <i className="fas fa-search fa-fw"></i>
                </button>
                
              </div>
            </div>
          </div>
          <div className="col-sm-2" style={{ marginLeft: "100px" }}>
            <Link to={`/CreateTinTuc/`}>
              <Button outline color="success" style={{ width: "150px"}}>
                Create
              </Button>
            </Link>
          </div>
        </div>
        
      </div>
      <br/>
      <Table  style ={{backgroundColor : "#e9d8f4", bordercollapse:"collapse",width:"1490px"}}>
     
        <thead>
          <tr style ={{backgroundColor : "#58257b", color:"white"}}>
            <th>STT</th>
            <th>NewsID</th>
            <th>NewsName</th>
            <th>Description</th>
            <th>Img</th>
            <th>UserID</th>
            <th>UserName</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {news.map(function (item, i) {
            return (
              <tr>
                <th scope="row">{i + 1}</th>
                <td>{item.newsID}</td>
                <td>{item.newsName}</td>
                <td>{item.description}</td>
                <td><img src={item.img} text={item.newsName} style={{height:"100px"}}/></td> 
                <td>{item.userID}</td>
                <td>{item.userName}</td>
                <td className="text-right">
                  <Link to={`/EditTinTuc/${item.newsID}`}>
                    <i
                      className="fas fa-edit"
                      style={{
                        marginLeft: "10px",
                        marginRight: "10px",
                        fontSize: "20px",  
                        float: "left",              
                      }}
                    >
                      {" "}
                    </i>
                  </Link>
                  <i
                    className="fas fa-trash-alt"
                    style={{
                      marginLeft: "10px",
                      marginRight: "30px",
                      fontSize: "20px",
                      color: "#E54646",
                    }}
                    onClick={() => handleDelete(item.newsID)}
                  ></i>
                </td>
              </tr>
            );
          })}
        </tbody>
      </Table>
    </div>
  );
};

export default ListTinTuc;
