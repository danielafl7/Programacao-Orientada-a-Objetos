using System;
using System.Collections.Generic;

class NCliente {
  private List<Cliente> clientes = new List<Cliente>();

  public List<Cliente> Listar() {
    clientes.Sort();
    return clientes;
  }

  public Cliente Listar(int id) {
    // Localiza na lista o cliente com o id informado
    for (int i = 0; i < clientes.Count; i++)
      if (clientes[i].Id == id) return clientes[i];
    return null;  
  }

  public void Inserir(Cliente c) {
    int max = 0;
    foreach(Cliente obj in clientes)
      if (obj.Id > max) max = obj.Id;
    c.Id = max + 1;      
    clientes.Add(c);
  } 

  public void Atualizar(Cliente c) {
    Cliente c_atual = Listar(c.Id);
    if (c_atual == null) return;
    c_atual.Nome = c.Nome;
    c_atual.Nascimento = c.Nascimento;
  } 

  public void Excluir(Cliente c) {
    if (c != null) clientes.Remove(c);
  } 
}