export class Order {
    constructor(
        public idOrders?: number,
        public caption?: string,
        public text?: string,
        public geomap?:string,
        public cost?: number,
        public usersId?: number,
        public thereImages?: boolean,
        public thereFiles?: boolean
    ){}
}
export class User{
    constructor(
        public idUsers?: number,
        public lastName?: string,
        public firstName?: string,
        public secondName?: string,
        public telephone?: number,
        public email?: string,
        public positionId?: number,
        public rulesId?: number,
        public companyId?: number,
        public pass?: string
    ){}
}
export class File{
    constructor(
        public IdFiles?: number,
        public Name?: string,
        public Url?: string,
        public UserId?: number
    ){}
}
export class Image{
    constructor(
        public IdImages?: number,
        public Name?: string,
        public Path?: string,
        public UserId?: number
    ){}
}
export class Company{
   constructor(
    public IdCompany?: number,
    public name?: string,
    public shortName?: string,
    public contacts?: string,
    public about?: string,
    public pan?: string,
    public addressId?: number,
    public isDeleted?: boolean){}
}