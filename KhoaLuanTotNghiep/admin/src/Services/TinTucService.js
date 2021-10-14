import httpClient from'../HttpClient'

class TinTucService {
  pathSer = "News";

  getList() {
    return httpClient.get(this.pathSer);
  }

  get(id){
    return httpClient.get(this.pathSer+"/"+id);
  }
  edit(id, objectEdit) {
    return httpClient.put(this.pathSer + "/" + id, objectEdit);
  }


  delete(id) {
    return httpClient.delete(this.pathSer + "/" + id);  
  }

  create(objectNew) {
    return httpClient.post(this.pathSer, objectNew);
  }
}
  export default new TinTucService();