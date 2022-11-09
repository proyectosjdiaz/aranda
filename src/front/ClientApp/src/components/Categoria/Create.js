import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class CategoriaCreate extends Component {
  static displayName = CategoriaCreate.name;

  constructor(props) {
    super(props);

    this.onChangeNombre = this.onChangeNombre.bind(this);

    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      creado: false,
      nombre: ''
    };

  }

  onChangeNombre(e) {

    this.setState({
      nombre: e.target.value
    });
  }

  onSubmit(e) {

    e.preventDefault();

    let requestCategoria = {
      nombre: this.state.nombre
    };

    fetch('categoria', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(requestCategoria)
    }).then(res => {

      return res.json();
    }).then(data => {

      this.setState({
        creado: true,
        nombre: ''
      });
    });
  }

  render() {

    let aviso = this.state.creado
      ? <div className="alert alert-success" role="alert">
        <strong>Excelente!</strong>. La categoria ha sido creada.
      </div>
      : '';

    return (
      <div className='container'>
        <h1>Categoria</h1>
        <h4>Creacion</h4>
        <hr />

        <div className='row'>
          <form onSubmit={this.onSubmit}>

            <div className='col-md-4'>
              <div className='form-group'>
                <label className='control-label'>Nombre</label>
                <input type='text' className='form-control' placeholder='Nombre de categoria' value={this.state.nombre} onChange={this.onChangeNombre} disabled={this.state.creado} />

              </div>
              <div className='form-group'>
                <input type='submit' value='Crear' className='btn btn-primary' disabled={this.state.creado} />
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
}

