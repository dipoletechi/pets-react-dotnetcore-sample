import http from "../http-common";
import IOwnerData from "../type/owner.type";

class OwnerDataService {
  getAll() {
    return http.get("/owner/all");
  }  

  getOwnerInfo(ownerId:number) {
    return http.get("/owner/getownerinfo/"+ownerId);
  }  

  getOwnerStats(ownerids:Array<number>) {
    return http.get("/owner/getstats/"+ownerids);
  }  
}

export default new OwnerDataService();