import { IProductBasicInfo } from "../interfaces/iproduct-basic-info";

export class ProductBasicInfo implements IProductBasicInfo {
    name: string ="";
    price: number=0;
    companyId: number=0;
    ageRestriction: number=0;
    description: string = "";
    imageIurl: string = "https://th.bing.com/th/id/R.2b53a072e24c01dd1e8829e8255e2384?rik=ow1u4G%2fDPduF5g&pid=ImgRaw&r=0&sres=1&sresct=1";
    storeId: number = 2;

  constructor(name: string, price: number, companyId: number, ageRestriction: number, description: string,imageIurl:string="", storeId:number=2) {
    this.name = name;
    this.price = price;
    this.companyId = companyId;
    this.ageRestriction = ageRestriction;
    this.description = description;
    this.imageIurl = (imageIurl != "") ? imageIurl : this.imageIurl;
    this.storeId = storeId;
  }

}
