export class Keep {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.creatorId = data.creatorId
    this.views = data.views
    this.kept = data.kept
    this.creator = data.creator
    this.vaultKeepId = data.vaultKeepId
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}