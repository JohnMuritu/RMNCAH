import { Navigate } from 'react-router-dom';
import DashboardLayout from 'src/components/DashboardLayout';
import MainLayout from 'src/components/MainLayout';
import RegisterClient from 'src/pages/RegisterClient';
import ClientClinicalDetailsPage from './pages/ClientClinicalDetailsPage';
import Account from 'src/pages/Account';
import CustomerList from 'src/pages/CustomerList';
import Dashboard from 'src/pages/Dashboard';
import Login from 'src/pages/Login';
import NotFound from 'src/pages/NotFound';
import ProductList from 'src/pages/ProductList';
import RegisterUserPage from 'src/pages/RegisterUserPage';
import Settings from 'src/pages/Settings';
import InlineDatePickerDemo from './components/client/InlineDatePickerDemo';
import Test from './components/client/Test';
import ReportsPage from './pages/ReportsPage';
import AddCHVPage from './pages/AddCHVPage';

const routes = (isLoggedIn) => [
  {
    path: 'app',
    element: isLoggedIn ? <DashboardLayout /> : <Navigate to="/login" />,
    //element: <DashboardLayout />,
    children: [
      { path: 'registerclient', element: <RegisterClient /> },
      { path: 'clientClinicalDetails', element: <ClientClinicalDetailsPage /> },
      { path: 'account', element: <Account /> },
      { path: 'adduser', element: <RegisterUserPage /> },
      { path: 'customers', element: <Test /> },
      { path: 'dashboard', element: <Dashboard /> },
      { path: 'products', element: <InlineDatePickerDemo /> },
      { path: 'settings', element: <Settings /> },
      { path: 'reports', element: <ReportsPage /> },
      { path: 'addchv', element: <AddCHVPage /> },
      { path: '*', element: <Navigate to="/404" /> }
    ]
  },
  {
    path: '/',
    element: <MainLayout />,
    children: [
      { path: 'login', element: <Login /> },
      // { path: 'register', element: <Register /> },
      { path: '404', element: <NotFound /> },
      { path: '/', element: <Navigate to="/app/registerclient" /> },
      { path: '*', element: <Navigate to="/404" /> }
    ]
  }
];

export default routes;
