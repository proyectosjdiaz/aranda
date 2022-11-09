import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class ProductoDelete extends Component {
  static displayName = ProductoDelete.name;

  constructor(props) {
    super(props);

    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      eliminado: false,
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

  onSubmit(e) {

    e.preventDefault();

    fetch(`categoria/${this.state.id}`, {
      method: 'DELETE'
    }).then(res => {

      return res.json();
    }).then(data => {

      this.setState({
        eliminado: true,
        id: this.state.id,
        nombre: this.state.nombre
      });
    });
  }

  render() {

    let aviso = this.state.eliminado
      ? <div className="alert alert-warning" role="alert">
        <strong>Excelente!</strong>. La categoria ha sido eliminada.
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
                <input type='text' className='form-control' placeholder='Nombre de categoria' readOnly value={this.state.nombre} />
                <span asp-validation-for='ProductModel.Name' className='text-danger'></span>
              </div>
              <div className='form-group'>
                <input type='submit' value='Eliminar' className='btn btn-danger' />
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
        eliminado: false,
        id: data.id,
        nombre: data.nombre
      });
    }
  }
}

