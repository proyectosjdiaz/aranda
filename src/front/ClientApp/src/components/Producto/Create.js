import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class ProductoCreate extends Component {
  static displayName = ProductoCreate.name;

  constructor(props) {
    super(props);

    this.onChangeCategoriaId = this.onChangeCategoriaId.bind(this);
    this.onChangeNombre = this.onChangeNombre.bind(this);
    this.onChangeDescripcion = this.onChangeDescripcion.bind(this);

    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      categorias: [],
      creado: false,
      nombre: '',
      categoriaId: 0,
      descripcion: ''
    };

  }

  componentDidMount() {
    this.populateCategorias();
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

    let requestProducto = {
      categoriaId: this.state.categoriaId,
      nombre: this.state.nombre,
      descripcion: this.state.descripcion
    };

    fetch('producto', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(requestProducto)
    }).then(res => {

      return res.json();
    }).then(data => {

      this.setState({
        creado: true,
        categoriaId: 0,
        nombre: '',
        descripcion: ''
      });
    });
  }

  render() {

    let aviso = this.state.creado
      ? <div className="alert alert-success" role="alert">
        <strong>Excelente!</strong>. El producto ha sido creada.
      </div>
      : '';

    return (
      <div className='container'>
        <h1>Producto</h1>
        <h4>Creacion</h4>
        <hr />

        <div className='row'>
          <form onSubmit={this.onSubmit}>

            <div className='col-md-4'>
              <div className='form-group'>
                <label className='control-label'>Categoria</label>
                <select className='form-control' onChange={this.onChangeCategoriaId} disabled={this.state.creado}>
                  <option>SELECCIONE CATEGORIA</option>
                  {this.state.categorias.map(categoria =>
                  <option value={categoria.id}>{categoria.nombre}</option>
                  )}
                </select>

              </div>
              <div className='form-group'>
                <label className='control-label'>Nombre</label>
                <input type='text' className='form-control' placeholder='Nombre de categoria' value={this.state.nombre} onChange={this.onChangeNombre} disabled={this.state.creado} />

              </div>
              <div className='form-group'>
                <label className='control-label'>Descripcion</label>
                <input type='text' className='form-control' placeholder='Nombre de categoria' value={this.state.descripcion} onChange={this.onChangeDescripcion} disabled={this.state.creado} />

              </div>
              <div className='form-group'>
                <input type='submit' value='Crear' className='btn btn-primary' disabled={this.state.creado} />
              </div>
            </div>

          </form>

          <div>
            {aviso}
            <Link to='/productos'>Regresar a productos</Link>
          </div>

        </div>

      </div>
    );
  }

  async populateCategorias() {
    const response = await fetch('categoria/categorias');
    const data = await response.json();
    this.setState({ categorias: data });
  }
}

