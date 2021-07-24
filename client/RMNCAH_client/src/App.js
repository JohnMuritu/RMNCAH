import 'react-perfect-scrollbar/dist/css/styles.css';
import { useSelector } from 'react-redux';
import { useRoutes } from 'react-router-dom';
import { ThemeProvider } from '@material-ui/core';
// React Notification
import 'react-notifications/lib/notifications.css';
import { NotificationContainer } from 'react-notifications';

import GlobalStyles from 'src/components/GlobalStyles';
import 'src/mixins/chartjs';
import theme from 'src/theme';
import routes from 'src/routes';

const App = () => {
  const isLoggedIn = useSelector((state) => state.main_reducer.authenticated);
  const routing = useRoutes(routes(isLoggedIn));
  // const routing = useRoutes(routes);

  return (
    <ThemeProvider theme={theme}>
      <GlobalStyles />
      <NotificationContainer />
      {routing}
    </ThemeProvider>
  );
};

export default App;
