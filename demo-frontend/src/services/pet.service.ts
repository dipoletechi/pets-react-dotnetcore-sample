import http from "../http-common";
import IPetData from "../type/pet.type";

class PetDataService {

  feed(petId:number) {
    return http.post("/pet/feed/"+petId);
  }  
}

export default new PetDataService();