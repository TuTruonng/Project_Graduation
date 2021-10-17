import React, { useState, useEffect } from "react";
import {useFormik} from "formik";
import{withRouter} from "react-router-dom";
import LoaiBatDongSanService from "../../Services/LoaiBatDongSanService";
import history from "../../Helpers/Help";
import './LoaiBDS.css';



const LoaiBDSForm = ({ match }) => {
  
  const [categoryID, setCategoryID] = useState(match.params.id);
  const [Category, setCategory] = useState({});

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      categoryName: Category.categoryName,
      categoryID: Category.categoryID,
      Description: Category.Description,
    },

    onSubmit: async (values) => {
      let result = window.confirm("Confirm");
      console.log(values);
      if (result) {
        let isCreate = categoryID === undefined ? true : false;
        console.log(isCreate);
        if (isCreate) {
          await LoaiBatDongSanService.create(values);
          history.goBack();
        } else {
          await LoaiBatDongSanService.edit(categoryID, values);
          history.goBack();
        }
      }  
    },
  });
   useEffect(() => {
    async function fetchdate() {
      setCategoryID(match.params.id);
      console.log(categoryID);
      if (categoryID !== undefined) {
        await fetchCategory(categoryID);
        console.log(formik.initialValues);
      } else {
      }
    }
    fetchdate();
  }, [match.params.id]);

  const fetchCategory = async (itemId) => {
    console.log(LoaiBatDongSanService.get(itemId));
    setCategory(await (await LoaiBatDongSanService.get(itemId)).data);
  };
  console.log(Category);


    return (
      <div className="content-wrapper" className="form" style={{width:"1300px",marginLeft:"300px"}}>
        <h3>Loại bất động sản</h3>
        <br/>
      <form onSubmit={formik.handleSubmit}  >
      <div className="form-group">
      <label htmlFor="CategoryName" className="text">Category Name: </label>
      <br/>
      <input className="input"
        id="CategoryName"
        name="CategoryName"
        type="text"
        onChange={formik.handleChange}
        value={formik.values.CategoryName}
      />
      </div>
        &nbsp;
        <br/>
        <div className="form-group">
        <label htmlFor="Description" className="text">Desciption: </label>
        <br/>
        <input className="input"
        id="Description"
        name="Description"
        type="text"
        onChange={formik.handleChange}
        value={formik.values.Desciption}
      />
      </div>
      &nbsp;
        <br/>
        <br/>
      <button type="submit" className="button">Submit</button>
    </form>
    </div>
  );
};

export default withRouter(LoaiBDSForm);