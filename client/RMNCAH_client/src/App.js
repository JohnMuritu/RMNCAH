import 'react-perfect-scrollbar/dist/css/styles.css';
import { useSelector } from 'react-redux';
import { useRoutes } from 'react-router-dom';
import { ThemeProvider } from '@material-ui/core';
// React Notification
import 'react-notifications/lib/notifications.css';
import { NotificationContainer } from 'react-notifications';
import axios from 'axios';

import GlobalStyles from 'src/components/GlobalStyles';
import 'src/mixins/chartjs';
import theme from 'src/theme';
import routes from 'src/routes';

const App = () => {
  const isLoggedIn = useSelector((state) => state.main_reducer.authenticated);
  const routing = useRoutes(routes(isLoggedIn));
  // const routing = useRoutes(routes);
  const AUTH_TOKEN = useSelector((state) => state.main_reducer.userToken);
  const bearer_token = `Bearer ${AUTH_TOKEN}`;
  //axios.defaults.baseURL = 'https://localhost:44346';
  axios.defaults.baseURL = 'http://localhost:90';
  axios.defaults.headers.common['Authorization'] = bearer_token;
  //axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';

  return (
    <ThemeProvider theme={theme}>
      <GlobalStyles />
      <NotificationContainer />
      {routing}
    </ThemeProvider>
  );
};

export default App;
