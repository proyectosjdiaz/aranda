import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { ProductoList } from "./components/Producto/List";
import { CategoriaList } from "./components/Categoria/List";
import { CategoriaCreate } from "./components/Categoria/Create";
import { CategoriaEdit } from "./components/Categoria/Edit";
import { CategoriaDelete } from "./components/Categoria/Delete";
import { ProductoCreate } from "./components/Producto/Create";
import { ProductoEdit } from "./components/Producto/Edit";
import { ProductoDelete } from "./components/Producto/Delete";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/productos',
    element: <ProductoList />
  },
  {
    path: '/categorias',
    element: <CategoriaList />
  },
  {
    path: '/categorias/crear',
    element: <CategoriaCreate />
  },
  {
    path: '/categorias/editar/:id',
    element: <CategoriaEdit />
  },
  {
    path: '/categorias/eliminar/:id',
    element: <CategoriaDelete />
  },
  {
    path: '/productos/crear',
    element: <ProductoCreate />
  },
  {
    path: '/productos/editar/:id',
    element: <ProductoEdit />
  },
  {
    path: '/productos/eliminar/:id',
    element: <ProductoDelete />
  }
];

export default AppRoutes;
