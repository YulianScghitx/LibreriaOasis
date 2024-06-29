import React from 'react';
import { useForm } from 'react-hook-form';

export default function App() {
  const { register, handleSubmit, formState: { errors } } = useForm();
  const onSubmit = data => console.log(data);
  console.log(errors);
  
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input type="text" placeholder="userName" {...register('userName', { required: 'username is required', maxLength: 20, pattern: '[A-Z][0-9]/i'})} />
      <input type="password" placeholder="password" {...register("password", {required: 'password is required', maxLength: 20})} />

      <input type="submit" />
    </form>
  );
}