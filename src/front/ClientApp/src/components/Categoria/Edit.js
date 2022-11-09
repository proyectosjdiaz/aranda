import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class CategoriaEdit extends Component {
  static displayName = CategoriaEdit.name;

  constructor(props) {
    super(props);

    this.onChangeNombre = this.onChangeNombre.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      modificado: false,
      id: 0,
      nombre: ''
    };

  }

  componentDidMount() {
    let queryString = window.location.pathname.split('/');
    if (queryString.length == 4) {

      this.findCategoria(parseInt(queryString[3]));
    }
  }

  onChangeNombre(e) {

    this.setState({
      nombre: e.target.value
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
        <strong>Excelente!</strong>. La categoria ha sido modificada.
      </div>
      : '';

    return (
      <div className='container'>
        <h1>Categoria</h1>
        <h4>Edicion</h4>
        <hr />

        <div className='row'>
          <form onSubmit={this.onSubmit}>

            <div className='col-md-4'>
              <div className='form-group'>
                <label className='control-label'>Nombre</label>
                <input type='text' className='form-control' placeholder='Nombre de categoria' value={this.state.nombre} onChange={this.onChangeNombre} />
                <span asp-validation-for='ProductModel.Name' className='text-danger'></span>
              </div>
              <div className='form-group'>
                <input type='submit' value='Modificar' className='btn btn-primary' />
              </div>
            </div>

          </form>

          <div>
            {aviso}
            <Link to='/categorias'>Regresar a categorias</Link>
          </div>

        </div>

      </div>
    );
  }

  async findCategoria(id) {
    if ((id || 0) > 0) {

      const response = await fetch(`categoria/${id}`);
      const data = await response.json();
      this.setState({
        modificado: false,
        id: data.id,
        nombre: data.nombre
      });
    }
  }
}

