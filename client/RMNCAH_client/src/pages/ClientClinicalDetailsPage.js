import { Helmet } from 'react-helmet';
import {
  Box,
  Container,
  Grid
} from '@material-ui/core';
import ClientClinicalDetails from 'src/components/client/ClientClinicalDetails';
import ClientList from 'src/components/client/ClientList';
import customers from 'src/__mocks__/customers';

const ClientClinicalDetailsPage = () => (
  <>
    <Helmet>
      <title>Register Client | RMNCAH</title>
    </Helmet>
    <Box
      sx={{
        backgroundColor: 'background.default',
        minHeight: '100%',
        py: 3
      }}
    >
      <Container maxWidth={false}>
        <Grid
          container
          spacing={3}
        >
          
          <Grid
            item
            lg={12}
            md={12}
            xs={12}
          >
            <ClientClinicalDetails />
          </Grid>
          <Grid
            item
            lg={12}
            md={12}
            xs={12}
          >
            <ClientList  customers={customers} />
          </Grid>
        </Grid>
      </Container>
    </Box>
  </>
);

export default ClientClinicalDetailsPage;
