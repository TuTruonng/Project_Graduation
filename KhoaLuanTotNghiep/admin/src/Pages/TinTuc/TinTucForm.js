import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import { withRouter } from "react-router-dom";
import TinTucService from "../../Services/TinTucService";
import history from "../../Helpers/Help";
import'./TinTuc.css';

const TinTucForm = ({ match }) => {

  const [newsID, setNewsID] = useState(match.params.id);
  const [News, setnews] = useState({});
  const [img, setImg] = useState("");
  const [isCreate, setIsCreate] = useState(match.params.id === undefined ? true : false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    async function fetchdata() {
      setNewsID(match.params.id);
      console.log("NewsID",newsID);
      if (newsID !== undefined) {
        await fetchNews(newsID);
      }

    }
    
    fetchdata();
  }, [match.params.id]);
  
  console.log("is creazzzz P", News);

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      newsName: News.newsName,
      userName: News.userName,
      description: News.description,
      userID: News.userID,
      img: News.img,
    }
    ,
    onSubmit: async (values) => {
      let result = window.confirm("Are you sure?");
      console.log("values ne",values);
      console.log(img);
      if (result) {
        if (isCreate) {
          await TinTucService.create( (values));
          history.goBack();
        } else {
          console.log("values edit", values);
          await TinTucService.edit(newsID, (values));
          history.goBack();
        }
      }
    },
  });


  const fetchNews = async (itemId) => {
    console.log(TinTucService.get(itemId));
    setnews(await (await TinTucService.get(itemId)).data);
  };

  const uploadImage = async (e) => {
    const files = e.target.files;
    const data = new FormData();
    data.append("file", files[0]);
    data.append("upload_preset", "leduyen");
    setLoading(true);
    console.log("acb",loading);
    const res = await fetch(
    " https://api.cloudinary.com/v1_1/dusq8k6rj/image/upload",
      {
        method: "POST",
        body: data,
      }
    );
    const file = await res.json();
    setImg(file.secure_url);
    setLoading(false);
    console.log("conmeo",img);
    console.log("conmeo2",file.secure_url); 
    if (isCreate) {
      formik.values.img =file.secure_url;
    }
    else {
      formik.values.img = file.secure_url;
    }
  };

  const changeFormikValuestoFormData = (valueForm) => {
    const formSubmitDataLocal = new FormData();
    formSubmitDataLocal.append('newsName', valueForm.newsName);
    formSubmitDataLocal.append('description', valueForm.description);
    formSubmitDataLocal.append('imageRequest', valueForm.imageRequest);
    console.log("FormData",formSubmitDataLocal);
    return formSubmitDataLocal;
  }

  console.log("run zzzz", formik.initialValues);

  return (
    <div class="content-wrapper"  className="form" style={{width:"1300px", height:"1000px",marginLeft:"300px"}}>
        <h3>Tin tức</h3>
        <br/>
      <form onSubmit={formik.handleSubmit}>
        <div className="form-group">
          <label htmlFor="newsName" className="text">News Name</label>
          <input className="input-form"
            id="newsName"
            name="newsName"
            type="text"
           {...formik.getFieldProps('newsName')}
           defaultValue={formik.values.newsName}
          />
        </div>
        <div className="form-group">
          <label htmlFor="userName" className="text">User Name</label>
          <input className="input-form"
            id="userName"
            name="userName"
            type="text"
             {...formik.getFieldProps('userName')}
             defaultValue={formik.values.userName}
          />
        </div>
        <div className="form-group">
          <label htmlFor="description" className="text">Description</label>
          <input className="input-form"
            id="description"
            name="description"
            type="text"
            
           {...formik.getFieldProps('description')}
           defaultValue={formik.values.description}
          />
        </div>
        <div className="form-group">
          <label htmlFor="img" className="text">Upload Image</label>
          <input className="input-form"
            type="file"
            id="img"
            name="img"
            placeholder="Upload an image"
            onChange={uploadImage}
            style={{ display: "block", paddingLeft:"200px" }}
          />
          {
            loading ? (
              <h3>Loading...</h3>
            ) : (
              <img src={img} style={{ width: "400px" }} alt="News-image" />
            )
          }
        </div>
        <button type="submit" className="button">Submit</button>

      </form>
    </div>
  );
};

export default withRouter(TinTucForm);

