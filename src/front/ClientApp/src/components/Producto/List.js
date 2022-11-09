import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class ProductoList extends Component {
  static displayName = ProductoList.name;

  constructor(props) {
    super(props);
    this.state = { productos: [], loading: true };
  }

  componentDidMount() {
    this.populateProductos();
  }

  static renderProductosTable(productos) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Categoria</th>
            <th>Nombre</th>
            <th>Descripcion</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {productos.map(producto =>
            <tr key={producto.id}>
              <td>{producto.id}</td>
              <td>{producto.categoria}</td>
              <td>{producto.nombre}</td>
              <td>{producto.descripcion}</td>
              <td>
                <Link to={`/productos/editar/${producto.id}`}>Editar</Link>
                |
                <Link to={`/productos/eliminar/${producto.id}`}>Eliminar</Link>
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
      : ProductoList.renderProductosTable(this.state.productos);

    return (
      <div>
        <h1 id="tabelLabel" >Productos</h1>
        <p>Se muestra productos guardados en base de datos.</p>
        <Link to='/productos/crear'>Crear</Link>
        {contents}
      </div>
    );
  }

  async populateProductos() {
    const response = await fetch('producto/productos');
    const data = await response.json();
    this.setState({ productos: data, loading: false });
  }
}
