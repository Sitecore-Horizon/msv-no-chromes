import { ComponentType } from 'react';
import {
  Link as JssLink,
  Text as JssText,
  Image as JssImage,
  RichText as JssRichText,
} from '@sitecore-jss/sitecore-jss-nextjs';

export interface FieldWrapperProps {
  metadata: any;
  children: React.ReactNode;
}

export const FieldWrapper = (props: FieldWrapperProps): JSX.Element => {
  const data = JSON.stringify(props.metadata);
  return (
    <>
      {/* 
// @ts-ignore */}
      <code type="text/sitecore" chrometype="field" kind="open" className='scpm'>
        {data}
      </code>
      {props.children}
      {/* 
// @ts-ignore */}
      <code type="text/sitecore" chrometype="field" kind="close" className='scpm'></code>
    </>
  );
};

export function withFieldWrapper<P extends {}>(FieldComp: ComponentType<P>) {
  return (props: P) => {
    const metadata = (props as any).field.metadata;

    if(!metadata) { 
      return (<FieldComp {...props} />) 
    }

    return (
      <FieldWrapper metadata={metadata}>
        <FieldComp {...props} />
      </FieldWrapper>
    );
  };
}

export const Link = withFieldWrapper(JssLink);
export const Text = withFieldWrapper(JssText);
export const Image = withFieldWrapper(JssImage);
// @ts-ignore
export const RichText = withFieldWrapper(JssRichText);
