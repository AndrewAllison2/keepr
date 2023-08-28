export class Profile {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.coverImg
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}