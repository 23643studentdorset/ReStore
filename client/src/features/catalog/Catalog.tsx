import { Checkbox, FormControl, FormControlLabel, FormGroup, FormLabel, Grid, Pagination, Paper, Radio, RadioGroup, TextField, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useEffect } from "react";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { fetchFilters, fetchProductsAsync, productSelectors } from "./catalogSlice";
import ProductList from "./ProductList";

const sortOptions = [
  {value: 'name', label: 'Alphabetical'},
  {value: 'priceDesc', label: 'Price - High to low'},
  {value: 'price', label: 'Price - Low to high'}
]

export default function Catalog (){
    const products = useAppSelector(productSelectors.selectAll);
    const {productsLoaded, status, filtersLoaded, brands, types} = useAppSelector (state => state.catalog);
    const dispatch = useAppDispatch();
    

  useEffect(() => {
    agent.Catalog.list()
    if(!productsLoaded) dispatch(fetchProductsAsync());
    }, [productsLoaded, dispatch])

  useEffect(() => {
    if(!filtersLoaded) dispatch(fetchFilters());
    }, [dispatch, filtersLoaded])

  if(status.includes('pending')) return <LoadingComponent message='Loading products...'/>
    return(
        <Grid container spacing={4}>  
          <Grid item xs={3}>
            <Paper sx={{ mb: 2}}>
              <TextField
                label ='Search products'
                variant='outlined'
                fullWidth
              />
            </Paper>
              
            <Paper sx={{ mb: 2, p: 2}}>
              <FormControl>          
                <RadioGroup>
                  {sortOptions.map(({value, label}) => (
                    <FormControlLabel value={value} control={<Radio />} label={label} key={value} />
                  ))}
                </RadioGroup>
              </FormControl>
            </Paper>
            
            <Paper sx={{ mb: 2, p: 2}}>
              <FormGroup>
                {brands.map(brand => (
                  <FormControlLabel control={<Checkbox/>} label={brand} key={brand}/>
                ))}
              </FormGroup>
            </Paper>
            
            <Paper sx={{ mb: 2, p: 2}}>
              <FormGroup>
                {types.map(types => (
                  <FormControlLabel control={<Checkbox/>} label={types} key={types}/>
                ))}
              </FormGroup>
            </Paper>
          </Grid>
          
          <Grid item xs={9}>
            <ProductList products={products}></ProductList>
          </Grid>
          
          <Grid item xs={3}/>
          <Grid item xs={9}>
            <Box display='flex' justifyContent='space-between' alignItems='center'>
                  <Typography>
                    Display 1-6 of 20 items
                  </Typography>
                  <Pagination 
                    color='secondary'
                    size='large'
                    count={10}
                    page={2}
                  />
            </Box>
          </Grid>
        </Grid>
      )
}