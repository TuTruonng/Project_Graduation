import httpClient from "../HttpClient";

class NhanVienService {
  pathSer = "user";

  getList() {
    return httpClient.get(this.pathSer);
  }
}
export default new NhanVienService();