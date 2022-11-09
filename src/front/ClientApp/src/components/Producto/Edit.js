import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class ProductoEdit extends Component {
  static displayName = ProductoEdit.name;

  constructor(props) {
    super(props);

    this.onChangeCategoriaId = this.onChangeCategoriaId.bind(this);
    this.onChangeNombre = this.onChangeNombre.bind(this);
    this.onChangeDescripcion = this.onChangeDescripcion.bind(this);

    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      categorias: [],
      modificado: false,
      nombre: '',
      categoriaId: 0,
      descripcion: ''
    };

  }

  componentDidMount() {
    let queryString = window.location.pathname.split('/');
    if (queryString.length == 4) {

      this.findProducto(parseInt(queryString[3]));
    }
  }

  onChangeNombre(e) {

    this.setState({
      nombre: e.target.value
    });
  }

  onChangeCategoriaId(e) {

    this.setState({
      categoriaId: parseInt(e.target.value)
    });
  }

  onChangeDescripcion(e) {

    this.setState({
      descripcion: e.target.value
    });
  }

  onSubmit(e) {

    e.preventDefault();

    let requestCategoria = {
      id: this.state.id,
      nombre: this.state.nombre
    };

    fetch('categoria', {
      method: 'PUT',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(requestCategoria)
    }).then(res => {

      return res.json();
    }).then(data => {

      this.setState({
        modificado: true,
        id: data.id,
        nombre: data.nombre
      });
    });
  }

  render() {

    let aviso = this.state.modificado
      ? <div className="alert alert-success" role="alert">
        <strong>Excelente!</strong>. El producto ha sido modificado.
      </div>
      : '';

    return (
      <div className='container'>
        <h1>Producto</h1>
        <h4>Edicion</h4>
        <hr />

        <div className='row'>
          <form onSubmit={this.onSubmit}>

            <div className='col-md-4'>
              <div className='form-group'>
                <label className='control-label'>Categoria</label>
                <select value={`${this.state.categoriaId}`} onChange={this.onChangeCategoriaId} className='form-control'>
                  <option>SELECCIONE</option>
                  {this.state.categorias.map((categoria, index) => {
                    return (<option key={index} value={categoria.id}>{categoria.nombre}</option>);
                  })}
                </select>

              </div>
              <div className='form-group'>
                <label className='control-label'>Nombre</label>
                <input type='text' className='form-control' placeholder='Nombre de categoria' value={this.state.nombre} onChange={this.onChangeNombre} />

              </div>
              <div className='form-group'>
                <label className='control-label'>Descripcion</label>
                <input type='text' className='form-control' placeholder='Nombre de categoria' value={this.state.descripcion} onChange={this.onChangeDescripcion} />

              </div>
              <div className='form-group'>
                <input type='submit' value='Modificar' className='btn btn-primary' disabled={this.state.creado} />
              </div>
            </div>

          </form>

          <div>
            {aviso}
            <Link to='/productos'>Regresar a categorias</Link>
          </div>

        </div>

      </div>
    );
  }

  async findProducto(id) {
    if ((id || 0) > 0) {

      const categorias = await this.populateCategorias();

      const response = await fetch(`producto/${id}`);
      const data = await response.json();
      this.setState({
        id: data.id,
        categorias: categorias,
        categoriaId: data.categoriaId,
        nombre: data.nombre,
        descripcion: data.descripcion
      });
    }
  }

  async populateCategorias() {
    const response = await fetch('categoria/categorias');
    const data = await response.json();
    return data;
  }
}

