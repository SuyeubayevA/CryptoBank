resource "hcloud_server" "crypto_bank_server" {
  name        = var.name
  image       = var.image
  server_type = var.server_type
  
  labels = {
    purpose : "api"
  }
}