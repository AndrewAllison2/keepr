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
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}



let update = {
  // "name": "Great Keep",
  // "description": "In ancient times a white sees a format as a fireproof crack. The burn of a light becomes an edging cell. A faucet can hardly be considered an exsert lyre without also being a shingle. An army is a file from the right perspective.",
  "img": "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=827&h=545&q=60",
  "creatorId": "64e531638df37119261dc706",
  "views": 0,
  "kept": 0,
  "creator": {
    "name": "Master Chef",
    "picture": "https://i.etsystatic.com/38852001/r/il/61857c/4440186628/il_fullxfull.4440186628_tqtf.jpg",
    "coverImg": null,
    "id": "64e531638df37119261dc706",
    "createdAt": "2023-08-22T22:06:29",
    "updatedAt": "2023-08-23T22:20:35"
  },
  "id": 1,
  "createdAt": "2023-08-25T17:39:31",
  "updatedAt": "2023-08-25T17:39:31"
}