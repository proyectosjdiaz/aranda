import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class CategoriaList extends Component {
  static displayName = CategoriaList.name;

  constructor(props) {
    super(props);
    this.state = { categorias: [], loading: true };
  }

  componentDidMount() {
    this.populateCategorias();
  }

  static renderCategoriasTable(categorias) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Categoria</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {categorias.map(categoria =>
            <tr key={categoria.id}>
              <td>{categoria.id}</td>
              <td>{categoria.nombre}</td>
              <td>
                <Link to={`/categorias/editar/${categoria.id}`}>Editar</Link>
                |
                <Link to={`/categorias/eliminar/${categoria.id}`}>Eliminar</Link>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : CategoriaList.renderCategoriasTable(this.state.categorias);

    return (
      <div>
        <h1 id="tabelLabel" >Categorias</h1>
        <p>Se muestra categorias guardadas en base de datos.</p>
        <Link to='/categorias/crear'>Crear</Link>
        {contents}
      </div>
    );
  }

  async populateCategorias() {
    const response = await fetch('categoria/categorias');
    const data = await response.json();
    this.setState({ categorias: data, loading: false });
  }
}
