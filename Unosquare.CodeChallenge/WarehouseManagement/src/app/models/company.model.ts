export class Company {
  public Id: number;
  public Name: string;

  constructor(Id: number , Name: string) {
    this.Id = Id;
    this.Name = Name;
  }

  getName(): string { return this.Name }
  getId(): number { return this.Id }
  setId(id: number) { this.Id = id }
  setName(name: string) { this.Name = name }
}
