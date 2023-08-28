export class Vault {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.isPrivate = data.isPrivate
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}


let d = {
  // "name": "My Favorite stuff",
  // "description": "Best things around!  Can't find a cooler collection",
  // "img": "https://images.unsplash.com/photo-1596998791568-386ef5297c2e?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&h=400&q=60",
  // "isPrivate": false,
  // "creatorId": "64e531638df37119261dc706",
  "creator": null,
  // "id": 86,
  "createdAt": "2023-08-28T16:28:54",
  "updatedAt": "2023-08-28T16:28:54"
}