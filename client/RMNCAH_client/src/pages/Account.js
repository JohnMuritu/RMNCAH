import { Helmet } from 'react-helmet';
import { Box, Container, Grid } from '@material-ui/core';
import AccountProfile from 'src/components/account/AccountProfile';
import AccountProfileDetails from 'src/components/account/AccountProfileDetails';
import SettingsPassword from 'src/components/account/SettingsPassword';

const Account = () => (
  <>
    <Helmet>
      <title>Account | RMNCAH</title>
    </Helmet>
    <Box
      sx={{
        backgroundColor: 'background.default',
        minHeight: '100%',
        py: 3
      }}
    >
      <Container maxWidth={false}>
        <Grid container spacing={3}>
          <Grid item lg={4} md={6} xs={12}>
            <AccountProfile />
          </Grid>
          <Grid item lg={8} md={6} xs={12}>
            <AccountProfileDetails />
            <Box sx={{ pt: 3 }}>
              <SettingsPassword />
            </Box>
          </Grid>
        </Grid>
      </Container>
    </Box>
  </>
);

export default Account;
