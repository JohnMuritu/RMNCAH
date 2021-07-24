import { useState } from 'react';
import {
  Box,
  Button,
  Card,
  CardContent,
  CardHeader,
  Divider,
  Grid,
  TextField
} from '@material-ui/core';

const ClientClinicalDetails = (props) => {
  const [values, setValues] = useState({
    firstName: 'Katarina',
    lastName: 'Smith',
    email: 'demo@devias.io',
    phone: '',
    state: 'Alabama',
    country: 'USA'
  });

  const handleChange = (event) => {
    setValues({
      ...values,
      [event.target.name]: event.target.value
    });
  };

  return (
    <form
      autoComplete="off"
      noValidate
      {...props}
    >
      <Card>
        <CardHeader
          subheader="Enter client clinical details"
          title="Client Clinical Details"
        />
        <Divider />
        <CardContent>
          <Grid
            container
            spacing={3}
          >
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="ANC 1"
                name="anc1"
                //type="date"
                defaultValue="blank"
                onChange={handleChange}
                value={values.anc1}
                //variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="ANC 2"
                name="anc2"
                //type="date"
                onChange={handleChange}
                value={values.anc2}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="ANC 3"
                name="anc3"
                //type="date"
                onChange={handleChange}
                value={values.anc3}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="ANC 4"
                name="anc4"
                //type="date"
                onChange={handleChange}
                value={values.anc4}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="ANC 5"
                name="anc5"
                //type="date"
                onChange={handleChange}
                value={values.anc5}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="EDD"
                name="edd"
                onChange={handleChange}
                required
                value={values.edd}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="SBA"
                name="sba"
                onChange={handleChange}
                required
                value={values.sba}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="PENTA1"
                name="penta1"
                onChange={handleChange}
                //type="date"
                value={values.penta1}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="PENTA2"
                name="penta2"
                onChange={handleChange}
                //type="date"
                value={values.penta2}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="PENTA3"
                name="penta3"
                onChange={handleChange}
                //type="date"
                value={values.penta3}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="MR1"
                name="mr1"
                onChange={handleChange}
                //type="date"
                value={values.mr1}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={4}
              xs={12}
            >
              <TextField
                fullWidth
                label="Remark"
                name="remark"
                onChange={handleChange}
                value={values.remark}
                variant="outlined"
              />
            </Grid>
          </Grid>
        </CardContent>
        <Divider />
        <Box
          sx={{
            display: 'flex',
            justifyContent: 'flex-end',
            p: 2
          }}
        >
          <Button
            color="primary"
            variant="contained"
          >
            Save details
          </Button>
        </Box>
      </Card>
    </form>
  );
};

export default ClientClinicalDetails;
