# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: azure_functions_worker/protos/NullableTypes.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from google.protobuf import timestamp_pb2 as google_dot_protobuf_dot_timestamp__pb2


DESCRIPTOR = _descriptor.FileDescriptor(
  name='azure_functions_worker/protos/NullableTypes.proto',
  package='',
  syntax='proto3',
  serialized_options=_b('\n*com.microsoft.azure.functions.rpc.messages'),
  serialized_pb=_b('\n1azure_functions_worker/protos/NullableTypes.proto\x1a\x1fgoogle/protobuf/timestamp.proto\"+\n\x0eNullableString\x12\x0f\n\x05value\x18\x01 \x01(\tH\x00\x42\x08\n\x06string\"+\n\x0eNullableDouble\x12\x0f\n\x05value\x18\x01 \x01(\x01H\x00\x42\x08\n\x06\x64ouble\"\'\n\x0cNullableBool\x12\x0f\n\x05value\x18\x01 \x01(\x08H\x00\x42\x06\n\x04\x62ool\"M\n\x11NullableTimestamp\x12+\n\x05value\x18\x01 \x01(\x0b\x32\x1a.google.protobuf.TimestampH\x00\x42\x0b\n\ttimestampB,\n*com.microsoft.azure.functions.rpc.messagesb\x06proto3')
  ,
  dependencies=[google_dot_protobuf_dot_timestamp__pb2.DESCRIPTOR,])




_NULLABLESTRING = _descriptor.Descriptor(
  name='NullableString',
  full_name='NullableString',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='value', full_name='NullableString.value', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
    _descriptor.OneofDescriptor(
      name='string', full_name='NullableString.string',
      index=0, containing_type=None, fields=[]),
  ],
  serialized_start=86,
  serialized_end=129,
)


_NULLABLEDOUBLE = _descriptor.Descriptor(
  name='NullableDouble',
  full_name='NullableDouble',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='value', full_name='NullableDouble.value', index=0,
      number=1, type=1, cpp_type=5, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
    _descriptor.OneofDescriptor(
      name='double', full_name='NullableDouble.double',
      index=0, containing_type=None, fields=[]),
  ],
  serialized_start=131,
  serialized_end=174,
)


_NULLABLEBOOL = _descriptor.Descriptor(
  name='NullableBool',
  full_name='NullableBool',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='value', full_name='NullableBool.value', index=0,
      number=1, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
    _descriptor.OneofDescriptor(
      name='bool', full_name='NullableBool.bool',
      index=0, containing_type=None, fields=[]),
  ],
  serialized_start=176,
  serialized_end=215,
)


_NULLABLETIMESTAMP = _descriptor.Descriptor(
  name='NullableTimestamp',
  full_name='NullableTimestamp',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='value', full_name='NullableTimestamp.value', index=0,
      number=1, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
    _descriptor.OneofDescriptor(
      name='timestamp', full_name='NullableTimestamp.timestamp',
      index=0, containing_type=None, fields=[]),
  ],
  serialized_start=217,
  serialized_end=294,
)

_NULLABLESTRING.oneofs_by_name['string'].fields.append(
  _NULLABLESTRING.fields_by_name['value'])
_NULLABLESTRING.fields_by_name['value'].containing_oneof = _NULLABLESTRING.oneofs_by_name['string']
_NULLABLEDOUBLE.oneofs_by_name['double'].fields.append(
  _NULLABLEDOUBLE.fields_by_name['value'])
_NULLABLEDOUBLE.fields_by_name['value'].containing_oneof = _NULLABLEDOUBLE.oneofs_by_name['double']
_NULLABLEBOOL.oneofs_by_name['bool'].fields.append(
  _NULLABLEBOOL.fields_by_name['value'])
_NULLABLEBOOL.fields_by_name['value'].containing_oneof = _NULLABLEBOOL.oneofs_by_name['bool']
_NULLABLETIMESTAMP.fields_by_name['value'].message_type = google_dot_protobuf_dot_timestamp__pb2._TIMESTAMP
_NULLABLETIMESTAMP.oneofs_by_name['timestamp'].fields.append(
  _NULLABLETIMESTAMP.fields_by_name['value'])
_NULLABLETIMESTAMP.fields_by_name['value'].containing_oneof = _NULLABLETIMESTAMP.oneofs_by_name['timestamp']
DESCRIPTOR.message_types_by_name['NullableString'] = _NULLABLESTRING
DESCRIPTOR.message_types_by_name['NullableDouble'] = _NULLABLEDOUBLE
DESCRIPTOR.message_types_by_name['NullableBool'] = _NULLABLEBOOL
DESCRIPTOR.message_types_by_name['NullableTimestamp'] = _NULLABLETIMESTAMP
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

NullableString = _reflection.GeneratedProtocolMessageType('NullableString', (_message.Message,), dict(
  DESCRIPTOR = _NULLABLESTRING,
  __module__ = 'azure_functions_worker.protos.NullableTypes_pb2'
  # @@protoc_insertion_point(class_scope:NullableString)
  ))
_sym_db.RegisterMessage(NullableString)

NullableDouble = _reflection.GeneratedProtocolMessageType('NullableDouble', (_message.Message,), dict(
  DESCRIPTOR = _NULLABLEDOUBLE,
  __module__ = 'azure_functions_worker.protos.NullableTypes_pb2'
  # @@protoc_insertion_point(class_scope:NullableDouble)
  ))
_sym_db.RegisterMessage(NullableDouble)

NullableBool = _reflection.GeneratedProtocolMessageType('NullableBool', (_message.Message,), dict(
  DESCRIPTOR = _NULLABLEBOOL,
  __module__ = 'azure_functions_worker.protos.NullableTypes_pb2'
  # @@protoc_insertion_point(class_scope:NullableBool)
  ))
_sym_db.RegisterMessage(NullableBool)

NullableTimestamp = _reflection.GeneratedProtocolMessageType('NullableTimestamp', (_message.Message,), dict(
  DESCRIPTOR = _NULLABLETIMESTAMP,
  __module__ = 'azure_functions_worker.protos.NullableTypes_pb2'
  # @@protoc_insertion_point(class_scope:NullableTimestamp)
  ))
_sym_db.RegisterMessage(NullableTimestamp)


DESCRIPTOR._options = None
# @@protoc_insertion_point(module_scope)
