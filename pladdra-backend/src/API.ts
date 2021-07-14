/* tslint:disable */
/* eslint-disable */
//  This file was automatically generated and should not be edited.

export type CreateAssetInput = {
  id?: string | null,
  name: string,
  type: AssetType,
  fileFormat: AssetFileFormat,
  fileName: string,
  fileSize: number,
  file: S3ObjectInput,
  description?: string | null,
};

export enum AssetType {
  MESH = "MESH",
}


export enum AssetFileFormat {
  GLTF = "GLTF",
  GLB = "GLB",
  OBJ = "OBJ",
  FBX = "FBX",
  DWG = "DWG",
}


export type S3ObjectInput = {
  bucket: string,
  key: string,
  region: string,
  localUri?: string | null,
  mimeType?: string | null,
  url?: string | null,
  _url?: string | null,
};

export type ModelAssetConditionInput = {
  name?: ModelStringInput | null,
  type?: ModelAssetTypeInput | null,
  fileFormat?: ModelAssetFileFormatInput | null,
  fileName?: ModelStringInput | null,
  fileSize?: ModelIntInput | null,
  description?: ModelStringInput | null,
  createdAt?: ModelStringInput | null,
  updatedAt?: ModelStringInput | null,
  and?: Array< ModelAssetConditionInput | null > | null,
  or?: Array< ModelAssetConditionInput | null > | null,
  not?: ModelAssetConditionInput | null,
};

export type ModelStringInput = {
  ne?: string | null,
  eq?: string | null,
  le?: string | null,
  lt?: string | null,
  ge?: string | null,
  gt?: string | null,
  contains?: string | null,
  notContains?: string | null,
  between?: Array< string | null > | null,
  beginsWith?: string | null,
  attributeExists?: boolean | null,
  attributeType?: ModelAttributeTypes | null,
  size?: ModelSizeInput | null,
};

export enum ModelAttributeTypes {
  binary = "binary",
  binarySet = "binarySet",
  bool = "bool",
  list = "list",
  map = "map",
  number = "number",
  numberSet = "numberSet",
  string = "string",
  stringSet = "stringSet",
  _null = "_null",
}


export type ModelSizeInput = {
  ne?: number | null,
  eq?: number | null,
  le?: number | null,
  lt?: number | null,
  ge?: number | null,
  gt?: number | null,
  between?: Array< number | null > | null,
};

export type ModelAssetTypeInput = {
  eq?: AssetType | null,
  ne?: AssetType | null,
};

export type ModelAssetFileFormatInput = {
  eq?: AssetFileFormat | null,
  ne?: AssetFileFormat | null,
};

export type ModelIntInput = {
  ne?: number | null,
  eq?: number | null,
  le?: number | null,
  lt?: number | null,
  ge?: number | null,
  gt?: number | null,
  between?: Array< number | null > | null,
  attributeExists?: boolean | null,
  attributeType?: ModelAttributeTypes | null,
};

export type Asset = {
  __typename: "Asset",
  id: string,
  name: string,
  type: AssetType,
  fileFormat: AssetFileFormat,
  fileName: string,
  fileSize: number,
  file: S3Object,
  description?: string | null,
  createdAt: string,
  updatedAt: string,
};

export type S3Object = {
  __typename: "S3Object",
  bucket: string,
  key: string,
  region: string,
};

export type UpdateAssetInput = {
  id: string,
  name?: string | null,
  type?: AssetType | null,
  fileFormat?: AssetFileFormat | null,
  fileName?: string | null,
  fileSize?: number | null,
  file?: S3ObjectInput | null,
  description?: string | null,
  createdAt?: string | null,
  updatedAt?: string | null,
};

export type DeleteAssetInput = {
  id: string,
};

export type ModelAssetFilterInput = {
  id?: ModelIDInput | null,
  name?: ModelStringInput | null,
  type?: ModelAssetTypeInput | null,
  fileFormat?: ModelAssetFileFormatInput | null,
  fileName?: ModelStringInput | null,
  fileSize?: ModelIntInput | null,
  description?: ModelStringInput | null,
  createdAt?: ModelStringInput | null,
  updatedAt?: ModelStringInput | null,
  and?: Array< ModelAssetFilterInput | null > | null,
  or?: Array< ModelAssetFilterInput | null > | null,
  not?: ModelAssetFilterInput | null,
};

export type ModelIDInput = {
  ne?: string | null,
  eq?: string | null,
  le?: string | null,
  lt?: string | null,
  ge?: string | null,
  gt?: string | null,
  contains?: string | null,
  notContains?: string | null,
  between?: Array< string | null > | null,
  beginsWith?: string | null,
  attributeExists?: boolean | null,
  attributeType?: ModelAttributeTypes | null,
  size?: ModelSizeInput | null,
};

export type ModelAssetConnection = {
  __typename: "ModelAssetConnection",
  items?:  Array<Asset | null > | null,
  nextToken?: string | null,
};

export type ModelAssetByFileFormatCompositeKeyConditionInput = {
  eq?: ModelAssetByFileFormatCompositeKeyInput | null,
  le?: ModelAssetByFileFormatCompositeKeyInput | null,
  lt?: ModelAssetByFileFormatCompositeKeyInput | null,
  ge?: ModelAssetByFileFormatCompositeKeyInput | null,
  gt?: ModelAssetByFileFormatCompositeKeyInput | null,
  between?: Array< ModelAssetByFileFormatCompositeKeyInput | null > | null,
  beginsWith?: ModelAssetByFileFormatCompositeKeyInput | null,
};

export type ModelAssetByFileFormatCompositeKeyInput = {
  createdAt?: string | null,
  updatedAt?: string | null,
};

export enum ModelSortDirection {
  ASC = "ASC",
  DESC = "DESC",
}


export type CreateAssetMutationVariables = {
  input: CreateAssetInput,
  condition?: ModelAssetConditionInput | null,
};

export type CreateAssetMutation = {
  createAsset?:  {
    __typename: "Asset",
    id: string,
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type UpdateAssetMutationVariables = {
  input: UpdateAssetInput,
  condition?: ModelAssetConditionInput | null,
};

export type UpdateAssetMutation = {
  updateAsset?:  {
    __typename: "Asset",
    id: string,
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type DeleteAssetMutationVariables = {
  input: DeleteAssetInput,
  condition?: ModelAssetConditionInput | null,
};

export type DeleteAssetMutation = {
  deleteAsset?:  {
    __typename: "Asset",
    id: string,
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type GetAssetQueryVariables = {
  id: string,
};

export type GetAssetQuery = {
  getAsset?:  {
    __typename: "Asset",
    id: string,
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type ListAssetsQueryVariables = {
  filter?: ModelAssetFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type ListAssetsQuery = {
  listAssets?:  {
    __typename: "ModelAssetConnection",
    items?:  Array< {
      __typename: "Asset",
      id: string,
      name: string,
      type: AssetType,
      fileFormat: AssetFileFormat,
      fileName: string,
      fileSize: number,
      file:  {
        __typename: "S3Object",
        bucket: string,
        key: string,
        region: string,
      },
      description?: string | null,
      createdAt: string,
      updatedAt: string,
    } | null > | null,
    nextToken?: string | null,
  } | null,
};

export type AssetsByFileFormatQueryVariables = {
  fileFormat?: AssetFileFormat | null,
  createdAtUpdatedAt?: ModelAssetByFileFormatCompositeKeyConditionInput | null,
  sortDirection?: ModelSortDirection | null,
  filter?: ModelAssetFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type AssetsByFileFormatQuery = {
  assetsByFileFormat?:  {
    __typename: "ModelAssetConnection",
    items?:  Array< {
      __typename: "Asset",
      id: string,
      name: string,
      type: AssetType,
      fileFormat: AssetFileFormat,
      fileName: string,
      fileSize: number,
      file:  {
        __typename: "S3Object",
        bucket: string,
        key: string,
        region: string,
      },
      description?: string | null,
      createdAt: string,
      updatedAt: string,
    } | null > | null,
    nextToken?: string | null,
  } | null,
};

export type OnCreateAssetSubscription = {
  onCreateAsset?:  {
    __typename: "Asset",
    id: string,
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnUpdateAssetSubscription = {
  onUpdateAsset?:  {
    __typename: "Asset",
    id: string,
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnDeleteAssetSubscription = {
  onDeleteAsset?:  {
    __typename: "Asset",
    id: string,
    name: string,
    type: AssetType,
    fileFormat: AssetFileFormat,
    fileName: string,
    fileSize: number,
    file:  {
      __typename: "S3Object",
      bucket: string,
      key: string,
      region: string,
    },
    description?: string | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};
